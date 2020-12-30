from numpy.random import randint


def find_sum(a_list, target):
    r = []
    sz = len(a_list)
    for i in range(sz):
        for j in range(i+1, sz):
            if (a_list[i] + a_list[j]) == target:
                r.append((a_list[i], a_list[j]))
    return r


def fast_sum(a_list, target):
    r = []
    h = {}
    for x in a_list:
        y = target - x
        if y in h:
            r.append(y, x)
        h[x] = x
    return r


if __name__ == '__main__':
    values = randint(0, 100, 20)
    target = randint(100)
    print(f"values {values} target {target}")
    print(find_sum(values, target))
